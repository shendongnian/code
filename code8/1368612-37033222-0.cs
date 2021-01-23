    private void WritePostInfo(BlogPosts post)
    {
        HttpContext.Current.Response.Write(String.Format("{0}, ", post.Content));
        HttpContext.Current.Response.Write(Environment.NewLine);
    }
