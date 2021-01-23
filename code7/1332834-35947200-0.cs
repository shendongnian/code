        public static void RedirectToSameDirectory(this HttpContextBase context, string fileName)
        {
            var builder = new UriBuilder(context.Request.Uri);
            builder.FileName = fileName;
            context.Response.Redirect(builder.Uri.ToString());
        }
    }
    // in razor
    Context.RedirectToSameDirectory("filename");
