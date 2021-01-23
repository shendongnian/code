    ♦ Notes on Creating DTOclassess.tt
			This T4 transform was created by first copying the working transform used to build the entity model, MedicalOfficeModel.tt.
			Then, parts of it that were not needed for creation of POCO classes to be used for DTO's (data transfer objects) were removed.
		♦ Changes made to DTOclassses.tt
			•   Adding "DTO" to namespace.
					public void BeginNamespace(CodeGenerationTools code)
					{
						var codeNamespace = String.Format("{0}.{1}",code.VsNamespaceSuggestion(), "DTO");
						if (!String.IsNullOrEmpty(codeNamespace))
						{
					#>
					namespace <#=code.EscapeNamespace(codeNamespace)#>
					{
					<#+
							PushIndent("    ");
						}
					}
			•  Put all POCO classes in single file DTOclasses.cs
					<#
					EndNamespace(code);
				}
				fileManager.Process(false);				<--**False stops the splitting of classes into different files. Default is true.
				#>
			•  Change the property naming code:
						public string Property(EdmProperty edmProperty)
						{
							return string.Format(
								CultureInfo.InvariantCulture,
								"{0} {1} {2} {{ {3}get; {4}set; }}",
								Accessibility.ForProperty(edmProperty),
								_typeMapper.GetTypeName(edmProperty.TypeUsage),
								GetPascalCase(_code.Escape(edmProperty)),
								_code.SpaceAfter(Accessibility.ForGetter(edmProperty)),
								_code.SpaceAfter(Accessibility.ForSetter(edmProperty)));
						}
			•  Change the class naming code:
						public string EntityClassOpening(EntityType entity)
						{
							return string.Format(
								CultureInfo.InvariantCulture,
								"{0} {1}partial class {2}{3}",
								Accessibility.ForType(entity),
								_code.SpaceAfter(_code.AbstractOption(entity)),
								GetPascalCase(_code.Escape(entity)),
								_code.StringBefore(" : ", _typeMapper.GetTypeName(entity.BaseType)));
						}
			•  Removed all the navigational stuff. Replaced everything above the helper functions (i.e., above <#+) with:
								<#@ template debug="false" hostspecific="true" language="C#" #>
								<#@ assembly name="System.Core" #>
								<#@ import namespace="System.Linq" #>
								<#@ import namespace="System.Text" #>
								<#@ import namespace="System.Collections.Generic" #>
								<#@ import namespace="System.Text.RegularExpressions" #>
								<#@ include file="EF6.Utility.CS.ttinclude" #>
								<#@ output extension=".cs" #>
								<#
								const string inputFile = @"MedicalOfficeModel.edmx";
								var textTransform = DynamicTextTransformation.Create(this);
								var code = new CodeGenerationTools(this);
								var ef = new MetadataTools(this);
								var typeMapper = new TypeMapper(code, ef, textTransform.Errors);
								var	fileManager = EntityFrameworkTemplateFileManager.Create(this);
								var itemCollection = new EdmMetadataLoader(textTransform.Host, textTransform.Errors).CreateEdmItemCollection(inputFile);
								var codeStringGenerator = new CodeStringGenerator(code, typeMapper, ef);
								if (!typeMapper.VerifyCaseInsensitiveTypeUniqueness(typeMapper.GetAllGlobalItems(itemCollection), inputFile))
								{
									return string.Empty;
								}
								WriteHeader(codeStringGenerator, fileManager);
								foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
								{
									fileManager.StartNewFile(entity.Name + ".cs");
									BeginNamespace(code);
								#>
								<#=codeStringGenerator.UsingDirectives(inHeader: false)#>
								<#=codeStringGenerator.EntityClassOpening(entity)#>
								{
								<#
									var simpleProperties = typeMapper.GetSimpleProperties(entity);
									if (simpleProperties.Any())
									{
										foreach (var edmProperty in simpleProperties)
										{
								#>
									<#=codeStringGenerator.Property(edmProperty)#>
								<#
										}
									}
								#>
								}
								<#
									EndNamespace(code);
								}
								fileManager.Process(false);
								#>
			♦  Added my helper function:
						<#+
							public static string GetPascalCase(string name)
							{
								return Regex.Replace(name, @"^\w|_\w",
									(match) => match.Value.Replace("_", "").ToUpper());
							}
						#>
