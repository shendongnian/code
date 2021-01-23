    public async InitialiseDataConnections()
    {           
        // Get SQLite and language setting
        await SQLiteData(); 
        // Update controls in page
        GetConnectionList(); 
    }    
