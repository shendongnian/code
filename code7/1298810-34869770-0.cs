     foreach (var tagId in MultipleTags)
                {
                    var tag = new Tag { TagId = tagId, TagName = "something" };
                    db.Tags.Attach(tag); // this avoids duplicate tags
                    post.Tags.Add(tag);
                }
