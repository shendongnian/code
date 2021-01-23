    public string attext
    {
        get
        {
            string aciklama_t_text = new TextRange(aciklama_t.Document.ContentStart, aciklama_t.Document.ContentEnd).Text;
            return aciklama_t_text;
        }
    }
