    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApplication1
    {
        [MyCustom("new sample text")]
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
                this.ResumeLayout(false);
            }
    
            #endregion
    
            public MyForm()
            {
                InitializeComponent();
            }
        }
    
        [MyCustom("sample text")]
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
    
            public MyCustomAttribute(string text = "")
            {
                this.Text = text;
            }
        }
    
        public class MyBaseFormDesigner : DocumentDesigner
        {
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                Verbs.Add(new DesignerVerb("Edit MyCustomAttribute text", OnEditText));            
            }
    
            protected virtual void OnEditText(object sender, EventArgs args)
            {
                EnvDTE._DTE dte = GetService(typeof(EnvDTE._DTE)) as EnvDTE._DTE;
                EnvDTE80.CodeClass2 codeClass = GetCodeClass(dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElements, "MyForm");
                EnvDTE80.CodeAttribute2 codeAttribute = GetCodeAttribute(codeClass, "MyCustom");
                if (codeAttribute != null) {
                    string newValue = Microsoft.VisualBasic.Interaction.InputBox("Current Text", "Edit MyCustomAttribute text", RemoveQuote(codeAttribute.Value), -1, -1);
                    codeAttribute.Value = (!string.IsNullOrWhiteSpace(newValue) ? "\"" + newValue + "\"" : "");
                }
            }
    
            private static string RemoveQuote(string str)
            {
                return !string.IsNullOrEmpty(str) && str[0] == '"' && str[str.Length - 1] == '"' ? str.Substring(1, str.Length - 2) : str;
            }
    
            private static EnvDTE80.CodeClass2 GetCodeClass(EnvDTE.CodeElements codeElements, string className)
            {
                if (codeElements != null) {
                    foreach (EnvDTE.CodeElement item in codeElements) {
                        if (item.Kind == EnvDTE.vsCMElement.vsCMElementClass) {
                            EnvDTE80.CodeClass2 codeClass = item as EnvDTE80.CodeClass2;
                            if (codeClass != null && codeClass.Name == className) return codeClass;
                        } else if (item.Kind == EnvDTE.vsCMElement.vsCMElementNamespace) {
                            EnvDTE80.CodeClass2 codeClass = GetCodeClass(((EnvDTE.CodeNamespace)item).Members, className);
                            if (codeClass != null && codeClass.Name == className) return codeClass;
                        }
                        
                    }
                }
                return null;
            }
    
            private static EnvDTE80.CodeAttribute2 GetCodeAttribute(EnvDTE80.CodeClass2 codeClass, string attributeName)
            {
                if (codeClass != null) {
                    foreach (EnvDTE80.CodeAttribute2 attr in codeClass.Attributes) {
                        if (attr.Name == attributeName) return attr;
                    }
                    return codeClass.AddAttribute(attributeName, "") as EnvDTE80.CodeAttribute2;
                }
                return null;
            }
        }
    }
