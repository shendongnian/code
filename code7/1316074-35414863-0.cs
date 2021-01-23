    public partial class ScratchXAML : Window
    {
        public ScratchXAML()
        {
            
            var mappingVM = new MappingViewModel(new CertificatesTableMapping());
            //This stuff would be done elsewhere but is temporarily in the code-behind for quick testing.
            mappingVM.ImportSourceFileName = "Test File Name";
            const string unmappedColumn1 = "Unmapped Column 1";
            const string unmappedColumn2 = "Unmapped Column 2";
            var unmappedColumns = new ObservableCollection<string>();
            unmappedColumns.Add(unmappedColumn1);
            unmappedColumns.Add(unmappedColumn2);
            //Back to reality -- this would probably be done in the code-behind of my views, unless there's a better way.
            mappingVM.UnmappedImportSourceColumns = unmappedColumns;
            this.DataContext = mappingVM;
          //move this line after the Data has been prepared
          InitializeComponent();
        }
    }
