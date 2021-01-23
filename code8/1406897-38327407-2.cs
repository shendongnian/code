     public class SourceControlViewModel : ViewModelBase
        {
    
     public IEnumerable<SourceControlItemViewBaseModel> SourceControlStructureItems { get; set; }
        public async Task Init()
        {
            await SourceControlRepository.Instance.Init();
            //Here the strucure builds
            SourceControlStructureItems = await SourceControlRepository.Instance.BuildSourceControlStructureAsync();
          
        }
    }
