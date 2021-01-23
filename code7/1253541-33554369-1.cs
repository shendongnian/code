       var CaseStudyContentTypeId = Services.ContentTypeService.GetContentType("CaseStudy").Id;
                
                var CaseStudies = Services.ContentService.GetContentOfContentType(CaseStudyContentTypeId).Select(x => new CaseStudy
                {
                    BannerImage = Umbraco.TypedMedia(x.GetValue<int>("bannerimage")).GetCropUrl("umbracoFile", "mobile"),
                    Url = Umbraco.Content(x.Id).Url.ToString(),
                    SectorName = Umbraco.Content(x.GetValue("selectSector")).Name,   //x.GetValue("selectSector").ToString(),
                    BodyTextHeading = x.GetValue("bodyTextHeading").ToString(),
                    BannerHeading = x.GetValue("bannerheading").ToString()
                });
