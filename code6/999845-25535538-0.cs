    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    /// using System.Threading.Tasks; <- .NET 4.5 only
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Common;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.ConnectorFramework;
    // using Microsoft.EnterpriseManagement.UI.Core;
    using Microsoft.EnterpriseManagement.UI.Extensions.Shared;
    using Microsoft.EnterpriseManagement.UI.FormsInfra;
    using Microsoft.EnterpriseManagement.UI.Core.Connection;
    using Microsoft.EnterpriseManagement.UI.DataModel;
    using Microsoft.EnterpriseManagement.UI.SdkDataAccess;
    using Microsoft.EnterpriseManagement.UI.SdkDataAccess.DataAdapters;
    using Microsoft.EnterpriseManagement.UI.WpfWizardFramework;
    using Microsoft.EnterpriseManagement.ServiceManager.Application.Common;
    using Microsoft.EnterpriseManagement.ConsoleFramework;
    using Microsoft.EnterpriseManagement.GenericForm;
    // using System.Management.Automation;
    [assembly: CLSCompliant(true)]
    
    namespace Flexity.RMA
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
    
        class RMATask : CreateWithLinkHandler
        {
            public RMATask()
            {
    
    
                try
                {
                    // Sealed Class GUID
                    this.createClassGuid = new Guid("9ebd95da-1b16-b9ea-274d-6b0c16ce1bf3");
                    this.classToDelegate = new Dictionary<Guid, CreateLinkHelperCallback>()
                    {
                        { ApplicationConstants.WorkItemTypeId, new CreateLinkHelperCallback (this.WorkItemCallback) }
                    };
                }
                catch (Exception exc1)
                {
                    MessageBox.Show(exc1.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
    
            public void WorkItemCallback(IDataItem RMAForm, IDataItem IncidentForm)
            {
                try
                {
                    // Note to self: RelatedWorkItems should be in MP XML as alias under TypeProjections
                    if (RMAForm != null && RMAForm.HasProperty("RelatedWorkItems"))
                    {
                        // Perform Linking
                        RMAForm["RelatedWorkItems"] = IncidentForm;
                        // Copy Incident Title to RMA Title
                        RMAForm["Title"] = IncidentForm["Title"];
                        // Copy Incident Description to RMA Description
                        RMAForm["Description"] = IncidentForm["Description"];
                    }
                }
                catch (Exception exc2)
                {
                    MessageBox.Show(exc2.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
