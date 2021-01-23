    public void SetViewModelValues(CreatePostViewModel viewModel)
    {
        Title = viewModel.Title;
        Thumbnail = viewModel.ThumbnailId != null ? db.Images.Find(viewModel.ThumbnailId) : null;
    }
