        public int PageCount
        {
            get
            {
                return (this._innerList.Count + this._itemsPerPage - 1) / this._itemsPerPage;
            }
        }
        public int EndIndex
        {
            get
            {
                int end = this._currentPage * this._itemsPerPage - 1;
                return (end > this._innerList.Count) ? this._innerList.Count : end;
            }
        }
