    interface IPattern
    {
        void UpdateIfMatch(String Line, bool Trim = true);
        void Reset();
        bool IsMatch();
        bool IsFound();
    }
    
    interface IDeletePattern : IPatten
    {    
        bool ShouldDelete();
    }
 
