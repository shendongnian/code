     body = body.Replace("#Title", blogTitle);
                body = body.Replace("#BlogDate", blogDate.ToString());
                body = body.Replace("#BlogCategory", blogCategory);
                body = body.Replace("#BlogHeadline", blogHeadline + ".........");
    
                mail.Body = body;
    AlternateView av1=AlternateView.CreateAlternateViewFromString(body,null,MediaTypeNames.Text.Html);
                LinkedResource myPhoto=new LinkedResource("D:\\asp.net\\Learning Dot Net\\myPhoto.jpg");
                myPhoto.ContentId="myImage";
                av1.LinkedResources.Add(myPhoto);
                myPhoto=new LinkedResource("D:\\asp.net\\Learning Dot Net\\books.jpg");
                myPhoto.ContentId="blogImage";
                av1.LinkedResources.Add(myPhoto);
                mail.AlternateViews.Add(av1);
                //code ends
    
                mail.IsBodyHtml = true;
