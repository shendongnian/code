    public class WizardStepsSerializer : CodeDomSerializer
    {
        /// <summary>
        /// We customize the output from the default serializer here, adding
        /// a comment and an extra line of code.
        /// </summary>
        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            // first, locate and invoke the default serializer for 
            // the ButtonArray's  base class (UserControl)
            //
            CodeDomSerializer baseSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(WizardStepsControl).BaseType, typeof(CodeDomSerializer));
            object codeObject = baseSerializer.Serialize(manager, value);
            // now add some custom code
            //
            if (codeObject is CodeStatementCollection)
            {
                // add a custom comment to the code.
                //
                CodeStatementCollection statements = (CodeStatementCollection)codeObject;
                statements.Insert(4, new CodeCommentStatement("This is a custom comment added by a custom serializer on " + DateTime.Now.ToLongDateString()));
                // call a custom method.
                //
                CodeExpression targetObject = base.SerializeToExpression(manager, value);
                WizardStepsControl wsc = (WizardStepsControl)value;
                if (targetObject != null && wsc.Steps != null)
                {
                    CodePropertyReferenceExpression leftNode = new CodePropertyReferenceExpression(targetObject, "Steps");
                    CodeObjectCreateExpression rightNode = new CodeObjectCreateExpression(typeof(Collection<Step>));
                    CodeAssignStatement initializeStepsStatement = new CodeAssignStatement(leftNode, rightNode);
                    statements.Insert(5, initializeStepsStatement);
                }
            }
            // finally, return the statements that have been created
            return codeObject;
        }
    }
