    public delegate bool CustomPreviewCreate(); // here we declare a return type
    public static event CustomPreviewCreate CustomPreviewCreate_Do;
    
    private void CreatePreview()
    {
        if (CustomPreviewCreate_Do !=null)
        {
            bool returnval = CustomPreviewCreate_Do();
        }
    }
