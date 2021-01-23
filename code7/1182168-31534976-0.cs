      namespace System.ServiceModel.Configuration 
        {
            using System.Configuration; 
            using System.ServiceModel.Channels; 
            using System.ServiceModel;
            using System.Collections.Generic; 
            using System.Globalization;
            using System.Reflection;
            using System.Xml;
            using System.Security; 
         
            public sealed partial class BindingsSection : ConfigurationSection, IConfigurationContextProviderInternal 
            { 
                static Configuration configuration = null;
                ConfigurationPropertyCollection properties; 
         
                public BindingsSection() { }
         
                Dictionary<string, bindingcollectionelement=""> BindingCollectionElements 
                {
                    get
                    { 
                        Dictionary<string, bindingcollectionelement=""> bindingCollectionElements = new Dictionary<string, bindingcollectionelement="">();
          
                        foreach (ConfigurationProperty property in this.Properties)
                        {
                            bindingCollectionElements.Add(property.Name, this[property.Name]);
                        } 
         
                        return bindingCollectionElements; 
                    } 
                }
          
                new public BindingCollectionElement this[string binding]
                {
                    get
                    { 
                        return (BindingCollectionElement)base[binding];
                    } 
                } 
         
                protected override ConfigurationPropertyCollection Properties 
                {
                    get
                    {
                        if (this.properties == null) 
                        {
                            this.properties = new ConfigurationPropertyCollection(); 
                        } 
         
                        this.UpdateBindingSections(); 
                        return this.properties;
                    }
                }
          
                [ConfigurationProperty(ConfigurationStrings.BasicHttpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)]
                public BasicHttpBindingCollectionElement BasicHttpBinding 
                { 
                    get { return (BasicHttpBindingCollectionElement)base[ConfigurationStrings.BasicHttpBindingCollectionElementName]; }
                } 
         
                // This property should only be called/set from BindingsSectionGroup TryAdd
                static Configuration Configuration
                { 
                    get { return BindingsSection.configuration; }
                    set { BindingsSection.configuration = value; } 
                } 
         
                [ConfigurationProperty(ConfigurationStrings.CustomBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public CustomBindingCollectionElement CustomBinding
                {
                    get { return (CustomBindingCollectionElement)base[ConfigurationStrings.CustomBindingCollectionElementName]; }
                } 
         
                [ConfigurationProperty(ConfigurationStrings.MsmqIntegrationBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public MsmqIntegrationBindingCollectionElement MsmqIntegrationBinding 
                {
                    get { return (MsmqIntegrationBindingCollectionElement)base[ConfigurationStrings.MsmqIntegrationBindingCollectionElementName]; } 
                }
         
                [ConfigurationProperty(ConfigurationStrings.NetPeerTcpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)]
                public NetPeerTcpBindingCollectionElement NetPeerTcpBinding 
                {
                    get { return (NetPeerTcpBindingCollectionElement)base[ConfigurationStrings.NetPeerTcpBindingCollectionElementName]; } 
                } 
         
                [ConfigurationProperty(ConfigurationStrings.NetMsmqBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public NetMsmqBindingCollectionElement NetMsmqBinding
                {
                    get { return (NetMsmqBindingCollectionElement)base[ConfigurationStrings.NetMsmqBindingCollectionElementName]; }
                } 
         
                [ConfigurationProperty(ConfigurationStrings.NetNamedPipeBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public NetNamedPipeBindingCollectionElement NetNamedPipeBinding 
                {
                    get { return (NetNamedPipeBindingCollectionElement)base[ConfigurationStrings.NetNamedPipeBindingCollectionElementName]; } 
                }
         
                [ConfigurationProperty(ConfigurationStrings.NetTcpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)]
                public NetTcpBindingCollectionElement NetTcpBinding 
                {
                    get { return (NetTcpBindingCollectionElement)base[ConfigurationStrings.NetTcpBindingCollectionElementName]; } 
                } 
         
                [ConfigurationProperty(ConfigurationStrings.WSFederationHttpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public WSFederationHttpBindingCollectionElement WSFederationHttpBinding
                {
                    get { return (WSFederationHttpBindingCollectionElement)base[ConfigurationStrings.WSFederationHttpBindingCollectionElementName]; }
                } 
         
                [ConfigurationProperty(ConfigurationStrings.WS2007FederationHttpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public WS2007FederationHttpBindingCollectionElement WS2007FederationHttpBinding 
                {
                    get { return (WS2007FederationHttpBindingCollectionElement)base[ConfigurationStrings.WS2007FederationHttpBindingCollectionElementName]; } 
                }
         
                [ConfigurationProperty(ConfigurationStrings.WSHttpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)]
                public WSHttpBindingCollectionElement WSHttpBinding 
                {
                    get { return (WSHttpBindingCollectionElement)base[ConfigurationStrings.WSHttpBindingCollectionElementName]; } 
                } 
         
                [ConfigurationProperty(ConfigurationStrings.WS2007HttpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public WS2007HttpBindingCollectionElement WS2007HttpBinding
                {
                    get { return (WS2007HttpBindingCollectionElement)base[ConfigurationStrings.WS2007HttpBindingCollectionElementName]; }
                } 
         
                [ConfigurationProperty(ConfigurationStrings.WSDualHttpBindingCollectionElementName, Options = ConfigurationPropertyOptions.None)] 
                public WSDualHttpBindingCollectionElement WSDualHttpBinding 
                {
                    get { return (WSDualHttpBindingCollectionElement)base[ConfigurationStrings.WSDualHttpBindingCollectionElementName]; } 
                }
         
                public static BindingsSection GetSection(Configuration config)
                { 
                    if (config == null)
                    { 
                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("config"); 
                    }
          
                    return (BindingsSection)config.GetSection(ConfigurationStrings.BindingsSectionGroupPath);
                }
         
                public List<bindingcollectionelement> BindingCollections 
                {
                    get
                    { 
                        List<bindingcollectionelement> bindingCollections = new List<bindingcollectionelement>();
                        foreach (ConfigurationProperty property in this.Properties) 
                        {
                            bindingCollections.Add(this[property.Name]);
                        }
          
                        return bindingCollections;
                    } 
                } 
         
                internal static bool TryAdd(string name, Binding binding, Configuration config, out string bindingSectionName) 
                {
                    bool retval = false;
                    BindingsSection.Configuration = config;
                    try
                    {
                        retval = BindingsSection.TryAdd(name, binding, out bindingSectionName); 
                    } 
                    finally
                    { 
                        BindingsSection.Configuration = null;
                    }
                    return retval;
                } 
         
                internal static bool TryAdd(string name, Binding binding, out string bindingSectionName) 
                { 
                    // TryAdd built on assumption that BindingsSectionGroup.Configuration is valid.
                    // This should be protected at the callers site.  If assumption is invalid, then 
                    // configuration system is in an indeterminate state.  Need to stop in a manner that
                    // user code can not capture.
                    if (null == BindingsSection.Configuration)
                    { 
                        DiagnosticUtility.DebugAssert("The TryAdd(string name, Binding binding, Configuration config, out string binding) variant of this function should always be called first. The Configuration object is not set.");
                        DiagnosticUtility.FailFast("The TryAdd(string name, Binding binding, Configuration config, out string binding) variant of this function should always be called first. The Configuration object is not set."); 
                    } 
         
                    bool retval = false; 
                    string outBindingSectionName = null;
                    BindingsSection sectionGroup = BindingsSection.GetSection(BindingsSection.Configuration);
                    sectionGroup.UpdateBindingSections();
                    foreach (string sectionName in sectionGroup.BindingCollectionElements.Keys) 
                    {
                        BindingCollectionElement bindingCollectionElement = sectionGroup.BindingCollectionElements[sectionName]; 
          
                        // Save the custom bindings as the last choice
                        if (!(bindingCollectionElement is CustomBindingCollectionElement)) 
                        {
                            MethodInfo tryAddMethod = bindingCollectionElement.GetType().GetMethod("TryAdd", BindingFlags.Instance | BindingFlags.NonPublic);
                            if (tryAddMethod != null)
                            { 
                                retval = (bool)tryAddMethod.Invoke(bindingCollectionElement, new object[] { name, binding, BindingsSection.Configuration });
                                if (retval) 
                                { 
                                    outBindingSectionName = sectionName;
                                    break; 
                                }
                            }
                        }
                    } 
                    if (!retval)
                    { 
                        // Much of the time, the custombinding should come out ok. 
                        CustomBindingCollectionElement customBindingSection = CustomBindingCollectionElement.GetBindingCollectionElement();
                        retval = customBindingSection.TryAdd(name, binding, BindingsSection.Configuration); 
                        if (retval)
                        {
                            outBindingSectionName = ConfigurationStrings.CustomBindingCollectionElementName;
                        } 
                    }
          
                    // This little oddity exists to make sure that the out param is assigned to before the method 
                    // exits.
                    bindingSectionName = outBindingSectionName; 
                    return retval;
                }
         
                /// <securitynote> 
                /// Critical - uses SecurityCritical method UnsafeLookupCollection which elevates
                /// Safe - does not leak config objects 
                /// </securitynote> 
                [SecurityCritical, SecurityTreatAsSafe]
                void UpdateBindingSections() 
                {
                    ExtensionElementCollection bindingExtensions = ExtensionsSection.UnsafeLookupCollection(ConfigurationStrings.BindingExtensions, ConfigurationHelpers.GetEvaluationContext(this));
         
                    // Extension collections are additive only (BasicMap) and do not allow for <clear> 
                    // or <remove> tags, nor do they allow for overriding an entry.  This allows us
                    // to optimize this to only walk the binding extension collection if the counts 
                    // mismatch. 
                    if (bindingExtensions.Count != this.properties.Count)
                    { 
                        foreach (ExtensionElement bindingExtension in bindingExtensions)
                        {
                            if (null != bindingExtension)
                            { 
                                if (!this.properties.Contains(bindingExtension.Name))
                                { 
                                    ConfigurationProperty property = new ConfigurationProperty(bindingExtension.Name, 
                                        Type.GetType(bindingExtension.Type, true),
                                        null, 
                                        ConfigurationPropertyOptions.None);
         
                                    this.properties.Add(property);
                                } 
                            }
                        } 
                    } 
                }
          
                /// <securitynote>
                /// Critical - uses SecurityCritical method UnsafeGetAssociatedBindingCollectionElement which elevates
                /// Safe - does not leak config objects
                /// </securitynote> 
                [SecurityCritical, SecurityTreatAsSafe]
                internal static void ValidateBindingReference(string binding, string bindingConfiguration, ContextInformation evaluationContext, ConfigurationElement configurationElement) 
                { 
                    // ValidateBindingReference built on assumption that evaluationContext is valid.
                    // This should be protected at the callers site.  If assumption is invalid, then 
                    // configuration system is in an indeterminate state.  Need to stop in a manner that
                    // user code can not capture.
                    if (null == evaluationContext)
                    { 
                        DiagnosticUtility.DebugAssert("ValidateBindingReference() should only called with valid ContextInformation");
                        DiagnosticUtility.FailFast("ValidateBindingReference() should only called with valid ContextInformation"); 
                    } 
         
                    if (!String.IsNullOrEmpty(binding)) 
                    {
                        BindingCollectionElement bindingCollectionElement = null;
         
                        if (null != evaluationContext) 
                        {
                            bindingCollectionElement = ConfigurationHelpers.UnsafeGetAssociatedBindingCollectionElement(evaluationContext, binding); 
                        } 
                        else
                        { 
                            bindingCollectionElement = ConfigurationHelpers.UnsafeGetBindingCollectionElement(binding);
                        }
         
                        if (bindingCollectionElement == null) 
                        {
                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ConfigurationErrorsException(SR.GetString(SR.ConfigInvalidSection, 
                                ConfigurationHelpers.GetBindingsSectionPath(binding)), 
                                configurationElement.ElementInformation.Source,
                                configurationElement.ElementInformation.LineNumber)); 
                        }
         
                        if (!String.IsNullOrEmpty(bindingConfiguration))
                        { 
                            if (!bindingCollectionElement.ContainsKey(bindingConfiguration))
                            { 
                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ConfigurationErrorsException(SR.GetString(SR.ConfigInvalidBindingName, 
                                    bindingConfiguration,
                                    ConfigurationHelpers.GetBindingsSectionPath(binding), 
                                    ConfigurationStrings.BindingConfiguration),
                                    configurationElement.ElementInformation.Source,
                                    configurationElement.ElementInformation.LineNumber));
                            } 
                        }
                    } 
                } 
         
                ContextInformation IConfigurationContextProviderInternal.GetEvaluationContext() 
                {
                    return this.EvaluationContext;
                }
          
                /// <securitynote>
                ///   RequiresReview - the return value will be used for a security decision -- see comment in interface definition 
                /// </securitynote> 
                ContextInformation IConfigurationContextProviderInternal.GetOriginalEvaluationContext()
                { 
                    DiagnosticUtility.DebugAssert("Not implemented: IConfigurationContextProviderInternal.GetOriginalEvaluationContext");
                    return null;
                }
            } 
        }
         
        </remove></clear></bindingcollectionelement></bindingcollectionelement></bindingcollectionelement></string,></string,></string,>
