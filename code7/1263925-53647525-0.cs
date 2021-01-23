    [Serializable]
    Class Article
    {
        Albums albumList { get; set; }
    
        [NonSerialized]
        Authors authorList { get; set; }
        ...
    }
