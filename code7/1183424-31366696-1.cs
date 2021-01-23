    <TextBox Text="{Binding Entry, Mode=TwoWay}"/>
    <TextBox Text="{Binding Name, Mode=TwoWay}"/>
    <TextBox Text="{Binding Displayid, Mode=TwoWay}"/>
.
    class ItemTemplateVM : BindableBase
    {
        private ItemTemplateModel itemTemplateModel;
    
        ...
        public ItemTemplateModel ItemTemplateModel
        {
            get { return this.itemTemplateModel; }
            set { SetProperty(ref this.itemTemplateModel, value); }
        }
    
        public string Entry {
            get { return itemTemplateModel.Entry; }
            set {
                if (itemTemplateModel.Entry == value)
                    return;
    
                itemTemplateModel.Entry = value;
                RaisePropertyChanged(); // I believe this is the prism variant of firing PropertyChanged
            }
        }
        // same for Name and DisplayId
