    [ParseChildren(true, DefaultProperty = "TestTemplates")]
    public class TestContainer : Control, INamingContainer
    {
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TestTemplateList TestTemplates { get; set; }
        // ... OnLoad and DataBind left intact
        protected override void CreateChildControls()
        {
            Controls.Clear();
            var phTest = new PlaceHolder();
            phTest.ID = "phTest";
            Controls.Add(phTest);
            if (this.TestTemplates != null)
            {
                foreach (var testTemplate in TestTemplates)
                {
                    ((ITemplate)testTemplate).InstantiateIn(phTest);    
                }
            }
            this.ChildControlsCreated = true;
        }
    }
