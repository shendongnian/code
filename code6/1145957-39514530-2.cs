     public sealed class OutputItemEditor : CollectionEditor // need a reference to System.Design.dll
    {
        public OutputItemEditor(Type type)
            : base(type)
        {
        }
        protected override Type[] CreateNewItemTypes()
        {
            return new[] { typeof(StaticOutputItem), typeof(VariableOutputItem),typeof(ExpressionOutputItem) };
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();            
            collectionForm.Text = "Output Collection";
            //Modify the Add Item Button Text
            try
            {
                //You can use "collectionForm.Controls.Find("addButton",true)" here also
                foreach (ToolStripItem item in collectionForm.Controls[0].Controls[1].Controls[0].ContextMenuStrip.Items)
                {
                    //Since Item Names are the Type Names
                    switch (item.Text)
                    {
                        case "StaticOutputItem":
                            item.Text = "Static Output Item";
                            break;
                        case "VariableOutputItem":
                            item.Text = "Variable Output Item";
                            break;
                        case "ExpressionOutputItem":
                            item.Text = "Expression Output Item";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return collectionForm;
        }
    }
