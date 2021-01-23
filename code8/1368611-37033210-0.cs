    private void WritePostInfo(BlogPosts post)
            {
                StringBuilder sb = new StringBuilder();
                AddComma(post.Content, sb);
                HttpContext.Current.Response.Write(sb.ToString()); // there's nothing in "sb" except commas at this point
                HttpContext.Current.Response.Write(Environment.NewLine);
            }
