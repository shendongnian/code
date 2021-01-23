    public ActionResult EditDocument(long documentId, string returnURL)
        {
            ViewBag.returnURL = returnURL;
            int userId = AccountController.GetLoggedInId(Session);
            string pageUrl = "Document/EditDocument";
            if (IsDocumentAccessible(documentId, pageUrl) && CheckOperation("EditDocument", pageUrl))
            {
                try
                {
                    spGetDocumentById_Result found = db.spGetDocumentById(documentId).ToArray()[0];
                    EditDocumentViewModel model = new EditDocumentViewModel()
                    {
                        DocumentId = found.DocumentId,
                        DocumentNumber = found.DocumentNumber,
                        DocumentDate = found.DocumentDate,
                        DocumentLevelType = (int)found.DocumentLevelTypeId,
                        AddressSrc = found.Address
                    };
                    List<spGetTagsOfDocument_Result> tags = db.spGetTagsOfDocument(documentId).ToList();
                    //foreach (spGetTagsOfDocument_Result tag in tags)
                    //{
                    //    model.selectedTags.Add(tag.TagName);
                    //}
                    List<spGetAllDocumentLevelType_Result> DocumentLevelTypeList = db.spGetAllDocumentLevelType(userId, pageUrl).ToList();
                    ViewBag.DocumentLevelTypeId = new SelectList(DocumentLevelTypeList, "DocumentLevelTypeId", "DocumentLevelTypeName", model.DocumentLevelType);
                    List<spGetAllTags_Result> TagList = db.spGetAllTags(AccountController.GetLoggedInId(Session), "Document/AddDocument").ToList();
                    //List<spGetAllTags_Result> selectedTags = TagList.Where(x => tags.Any(y => y.TagId == x.TagId)).ToList();
                    IEnumerable<SelectListItem> items = from tag in TagList
                                                        select new SelectListItem
                                                        {
                                                            Text = tag.TagName.ToString(),
                                                            Value = tag.TagId.ToString(),
                                                            Selected = tags.Any(y => y.TagId == tag.TagId),
                                                        };
                    //ViewBag.tags = new MultiSelectList(TagList, "TagId", "TagName", model.selectedTags.ToArray());
                    ViewBag.tags = items;
                    return View(model);
                }
                catch (Exception)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }
