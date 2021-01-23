     var res = ElasticClient.CreateIndex("pages", i => i.Mappings(m => m.Map<ESPageViewModel>(mm => mm.AutoMap())));
                    var page = new ESPageViewModel
                    {
                        Id = dbPage.Id,
                        PageId = dbPage.PageId,
                        Name = dbPage.Name,
                        Options = pageTags,
                        CustomerCategoryId = saveTagOptions.CustomerCategoryId,
                        Link = dbPage.Link,
                        Price = dbPage.Price
                    };
                    var pages = new List<ESPageViewModel>() { page };
                    var res2 = ElasticClient.IndexManyAsync<ESPageViewModel>(pages, "pages");
