    public List<Folder> m_FolderList
    {
            get
            {
                
                    List<Folder> list = new List<Process>();
                    list.AddRange(Manager.Instance.GetFolderDirectory().Values);
                    return list;
            }
    }
