    using xxx.CFM.UI.Core;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace xxx.CFM.UI.Forms
    {
        /// <summary>
        /// Form used to inspect objects at runtime
        /// </summary>
        public partial class frmInspector : BaseForm
        {
            #region Properties
    
            /// <summary>
            /// Gets or Sets the 
            /// </summary>
            public object SelectedObject
            {
                get { return propertyGrid.SelectedObject; }
                set { propertyGrid.SelectedObject = value; }
            }
    
            #endregion Properties
    
            #region Constructor
    
            /// <summary>
            /// Constructor
            /// </summary>
            public frmInspector(object objectToInspect)
            {
                try
                {
                    InitializeComponent();
    
                    this.SelectedObject = objectToInspect;
                }
                catch (Exception ex)
                {
                    UIMessage.DisplayError(ex);
                }
            }
    
            #endregion Constructor
    
            #region Events
    
            /// <summary>
            /// Closes the form
            /// </summary>
            /// <param name="sender">object</param>
            /// <param name="e">args</param>
            private void btnClose_Click(object sender, EventArgs e)
            {
                try
                {
                    this.Close();
                }
                catch (Exception ex)
                {
                    UIMessage.DisplayError(ex);
                }
            }
    
            #endregion Events
        }
    }
