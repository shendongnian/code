    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class configuration
    {
    
        [System.Xml.Serialization.XmlArrayItemAttribute("assemblyBinding", Namespace = "urn:schemas-microsoft-com:asm.v1", IsNullable = false)]
        public assemblyBinding[] runtime { get; set; }
    }
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:asm.v1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:schemas-microsoft-com:asm.v1", IsNullable = false)]
    public partial class assemblyBinding
    {
    
        public assemblyBindingDependentAssembly dependentAssembly { get; set; }
    }
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:asm.v1")]
    public partial class assemblyBindingDependentAssembly
    {
    
        public assemblyBindingDependentAssemblyAssemblyIdentity assemblyIdentity { get; set; }
    
        public assemblyBindingDependentAssemblyBindingRedirect bindingRedirect { get; set; }
    }
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:asm.v1")]
    public partial class assemblyBindingDependentAssemblyAssemblyIdentity
    {
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { get; set; }
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string publicKeyToken { get; set; }
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string culture { get; set; }
    }
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:asm.v1")]
    public partial class assemblyBindingDependentAssemblyBindingRedirect
    {
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oldVersion { get; set; }
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string newVersion { get; set; }
    }
