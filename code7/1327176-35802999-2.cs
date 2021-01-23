    using Microsoft.OData.Edm;
    using Microsoft.OData.Edm.Library;
    // config is an instance of HttpConfiguration
	config.EnableAlternateKeys(true);
    // builder is an instance of ODataConventionModelBuilder
	var edmModel = builder.GetEdmModel() as EdmModel;
	var employeeType = edmModel.FindDeclaredType(typeof(Employee).FullName) as IEdmEntityType;
	var employeeNameProp = employeeType.FindProperty("Name");
	edmModel.AddAlternateKeyAnnotation(employeeType, new Dictionary<string, IEdmProperty> { { "Name", employeeNameProp } });
