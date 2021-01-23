    //
    //  @(#) FormViewControl.cs
    //
    //  Project:    usis.ManagementConsole
    //  System:     Microsoft Visual Studio 2015
    //  Author:     Udo Schäfer
    using System;
    using System.Windows.Forms;
    using Microsoft.ManagementConsole;
    namespace usis.ManagementConsole
    {
        //  ---------------------
        //  FormViewControl class
        //  ---------------------
        /// <summary>
        /// Provides an empty control that can be used to create the content of a Windows Forms view.
        /// </summary>
        /// <seealso cref="UserControl" />
        /// <seealso cref="IFormViewControl" />
        public class FormViewControl : UserControl, IFormViewControl
        {
            #region fields
            private Control oldParent;
            #endregion fields
            #region properties
            //  -----------------
            //  FormView property
            //  -----------------
            /// <summary>
            /// Gets the associated Windows Forms view.
            /// </summary>
            /// <value>
            /// The form view.
            /// </value>
            protected FormView FormView { get; private set; }
            //  ---------------
            //  SnapIn property
            //  ---------------
            /// <summary>
            /// Gets the scope node's snap-in.
            /// </summary>
            /// <value>
            /// The scope node's snap-in.
            /// </value>
            protected NamespaceSnapInBase SnapIn
            {
                get { return this.FormView.ScopeNode.SnapIn; }
            }
            #endregion properties
            #region overrides
            //  ----------------------
            //  OnParentChanged method
            //  ----------------------
            /// <summary>
            /// Raises the <see cref="Control.ParentChanged"/> event.
            /// </summary>
            /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
            protected override void OnParentChanged(EventArgs e)
            {
                if (Parent != null)
                {
                    if (!DesignMode) Size = Parent.ClientSize;
                    Parent.SizeChanged += Parent_SizeChanged;
                }
                if (oldParent != null)
                {
                    oldParent.SizeChanged -= Parent_SizeChanged;
                }
                oldParent = Parent;
                base.OnParentChanged(e);
            }
            #endregion overrides
            #region IFormViewControl implementation
            //  -----------------
            //  Initialize method
            //  -----------------
            /// <summary>
            /// Uses the associated Windows Forms view to initialize the control.
            /// </summary>
            /// <param name="view">The associated <c>FormView</c> value.</param>
            public void Initialize(FormView view)
            {
                FormView = view;
                OnInitialize();
            }
            //  -------------------
            //  OnInitialize method
            //  -------------------
            /// <summary>
            /// Called when the control is initialized.
            /// </summary>
            protected virtual void OnInitialize() { }
            #endregion IFormViewControl implementation
            #region private methods
            //  -------------------------
            //  Parent_SizeChanged method
            //  -------------------------
            private void Parent_SizeChanged(object sender, EventArgs e)
            {
                if (!DesignMode) Size = Parent.ClientSize;
            }
            #endregion private methods
        }
    }
    // eof "FormViewControl.cs"
