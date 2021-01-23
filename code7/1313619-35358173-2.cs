    public class FolderService
    {
        private IFoldersRepository _foldersRepository;
    
        public FolderService(IFoldersRepository foldersRepository)
        {
            _foldersRepository = foldersRepository;
        }
    
        public bool SaveFolder(Folder folder)
        {
    		if (folder == null)
    			return false;
    
    		if (folder.Id == 0)
    		{
    			folder.CreateOnDate = DateTime.Now;
    			Context.NewsArticles.Add(folder);
    		}
    		
    		//change this to cast the SaveChanges to bool
    		// also not so sure this is a gd idea... bt thats by the by for this....
    		//---------------------
    		try 
    		{
    			Context.SaveChanges();
    			return true;
    		}
    		catch(exception ex)
    		{
    			return false;
    		}
    		//---------------------
        }
    }
