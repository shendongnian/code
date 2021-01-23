    while (_myReader_1.Read())
    {
       _Row_Counter++;
    
       int _authorID = _myReader_1.GetInt32(0);
       Author _author = _eAthors.FirstOrDefault(_a => _a._AuthorID == _authorID);
       if (_author == null)
       {
          _author = new Author
          {
             _AuthorID = _authorID,
             _AuthorName = _myReader_1.GetString(1),
             _Attributes = new List<AuthorAttributes>()
          };  
          _eAthors.Add(_author); // ********** Add the new author
       }  
       // Watch out!!! author.Attributes may be null for existing authors!!!
       if (author.Attributes.PaperID == null || author.PaperID.Count == 0) // Check for PaperID existence
       {
           var _attribute = new AuthorAttributes()
           {
              _PaperID = new List<int>(),
              _CoAuthorID = new List<int>(),
              _VenueID = new List<int>()
           };
    
           _attribute._PaperID.Add(_myReader_1.GetInt32(2));
           _attribute._CoAuthorID.Add(_myReader_1.GetInt32(3));
           _attribute._VenueID.Add(_myReader_1.GetInt32(4));
           _attribute._Year = _myReader_1.GetInt32(5);
    
           _author._Attributes.Add(_attribute);
       }
    }
    _myReader_1.Close();  
