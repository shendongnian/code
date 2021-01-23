    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApplication1
    {
        [MyCustom("Example 1", 1), MyCustom("Example 2", 2)]
        public class MyForm : MyBaseForm
        {
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // MyForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.ClientSize = new System.Drawing.Size(617, 450);
                this.Name = "MyForm";
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            public MyForm()
            {
                InitializeComponent();
            }
        }
    
        [Designer(typeof(MyBaseFormDesigner), typeof(IRootDesigner))]
        public partial class MyBaseForm : Form
        {
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // MyBaseForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(391, 337);
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            public MyBaseForm()
            {
                InitializeComponent();
            }
        }
    
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
        public class MyCustomAttribute : Attribute
        {
            public string Text { get; set; }
            public int IntValue { get; set; }
    
            public MyCustomAttribute(string text, int intValue)
            {
                this.Text = text;
                this.IntValue = intValue;
            }
        }
    
        public class MyBaseFormDesigner : DocumentDesigner
        {
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                Verbs.Add(new DesignerVerb("Remove Attributes", OnRemoveAttributes));            
            }
    
            protected virtual void OnRemoveAttributes(object sender, EventArgs args)
            {
                EnvDTE._DTE dte = GetService(typeof(EnvDTE._DTE)) as EnvDTE._DTE;
                EnvDTE80.CodeClass2 codeClass = GetCodeClass(dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElements, "MyForm");
                while (codeClass.Attributes.Count > 0) {
                    ((EnvDTE80.CodeAttribute2)codeClass.Attributes.Item(1)).Delete(); // Attributes array starts from 1 not 0
                }
            }
    
            private static EnvDTE80.CodeClass2 GetCodeClass(EnvDTE.CodeElements codeElements, string name)
            {
                EnvDTE80.CodeClass2 codeClass = null;
                foreach (EnvDTE.CodeElement item in codeElements) {
                    if (item.Kind == EnvDTE.vsCMElement.vsCMElementClass) {
                        codeClass = item as EnvDTE80.CodeClass2;
                    } else if (item.Kind == EnvDTE.vsCMElement.vsCMElementNamespace) {                    
                        codeClass = GetCodeClass(((EnvDTE.CodeNamespace)item).Members, name);
                    }
                    if (codeClass != null && codeClass.Name == name) break;
                }
                return codeClass;
            }
        }
    }
