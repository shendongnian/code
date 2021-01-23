    [MulticastAttributeUsage(PersistMetaData = true)]
    public class FileExtensionValidationPolicy : AssemblyLevelAspect
    {
        public override bool CompileTimeValidate( Assembly assembly )
        {
            ISyntaxReflectionService reflectionService = PostSharpEnvironment.CurrentProject.GetService<ISyntaxReflectionService>();
            MethodInfo[] validatedMethods = new[]
            {
                typeof(FileExtensionAttributeHelper).GetMethod( "GetFileExtensions", BindingFlags.Public | BindingFlags.Static ),
                typeof(FileExtensionAttributeHelper).GetMethod( "GetPrimaryFileExtension", BindingFlags.Public | BindingFlags.Static )
            };
            MethodBase[] referencingMethods =
                validatedMethods
                    .SelectMany( ReflectionSearch.GetMethodsUsingDeclaration )
                    .Select( r => r.UsingMethod )
                    .Where( m => !validatedMethods.Contains( m ) )
                    .Distinct()
                    .ToArray();
            foreach ( MethodBase userMethod in referencingMethods )
            {
                ISyntaxMethodBody body = reflectionService.GetMethodBody( userMethod, SyntaxAbstractionLevel.ExpressionTree );
                ValidateMethodBody(body, userMethod, validatedMethods);
            }
            return false;
        }
        private void ValidateMethodBody(ISyntaxMethodBody methodBody, MethodBase userMethod, MethodInfo[] validatedMethods)
        {
            MethodBodyValidator validator = new MethodBodyValidator(userMethod, validatedMethods);
            validator.VisitMethodBody(methodBody);
        }
        private class MethodBodyValidator : SyntaxTreeVisitor
        {
            private MethodBase userMethod;
            private MethodInfo[] validatedMethods;
            public MethodBodyValidator( MethodBase userMethod, MethodInfo[] validatedMethods )
            {
                this.userMethod = userMethod;
                this.validatedMethods = validatedMethods;
            }
            public override object VisitMethodCallExpression( IMethodCallExpression expression )
            {
                foreach ( MethodInfo validatedMethod in this.validatedMethods )
                {
                    if ( validatedMethod != expression.Method )
                        continue;
                    this.ValidateTypeOfExpression(validatedMethod, expression.Arguments[0]);
                    this.ValidateGetTypeExpression(validatedMethod, expression.Arguments[0]);
                }
                return base.VisitMethodCallExpression( expression );
            }
            private void ValidateTypeOfExpression(MethodInfo validatedMethod, IExpression expression)
            {
                IMethodCallExpression callExpression = expression as IMethodCallExpression;
                if (callExpression == null)
                    return;
                if (callExpression.Method != typeof(Type).GetMethod("GetTypeFromHandle"))
                    return;
                IMetadataExpression metadataExpression = callExpression.Arguments[0] as IMetadataExpression;
                if (metadataExpression == null)
                    return;
                Type type = metadataExpression.Declaration as Type;
                if (type == null)
                    return;
                if (!type.GetCustomAttributes(typeof(FileExtensionAttribute)).Any())
                {
                    MessageSource.MessageSink.Write(
                        new Message(
                            MessageLocation.Of( this.userMethod ),
                            SeverityType.Error, "MYERR1",
                            String.Format( "Calling method {0} on type {1} is not allowed.", validatedMethod, type ),
                            null, null, null
                            )
                        );
                }
            }
            private void ValidateGetTypeExpression(MethodInfo validatedMethod, IExpression expression)
            {
                IMethodCallExpression callExpression = expression as IMethodCallExpression;
                if (callExpression == null)
                    return;
                if (callExpression.Method != typeof(Type).GetMethod("GetType"))
                    return;
                IExpression instanceExpression = callExpression.Instance;
                Type type = instanceExpression.ReturnType;
                if (type == null)
                    return;
                if (!type.GetCustomAttributes(typeof(FileExtensionAttribute)).Any())
                {
                    MessageSource.MessageSink.Write(
                        new Message(
                            MessageLocation.Of(this.userMethod),
                            SeverityType.Error, "MYERR1",
                            String.Format("Calling method {0} on type {1} is not allowed.", validatedMethod, type),
                            null, null, null
                            )
                        );
                }
            }
        }
    }
