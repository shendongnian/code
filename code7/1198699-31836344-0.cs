    public class ShowDuplicateBooksController : ObjectViewController<ListView, Book> 
    {
        public ShowDuplicateBooksController() 
        {
            PopupWindowShowAction showDuplicatesAction = 
                new PopupWindowShowAction(this, "ShowDuplicateBooks", "View");
            showDuplicatesAction.CustomizePopupWindowParams += showDuplicatesAction_CustomizePopupWindowParams;
        }
        void showDuplicatesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) 
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(Book book in View.CollectionSource.List) {
                if(!string.IsNullOrEmpty(book.Title)) {
                    if(dictionary.ContainsKey(book.Title)) {
                        dictionary[book.Title]++;
                    }
                    else 
                        dictionary.Add(book.Title, 1);
                }
            }
            DuplicatesList duplicateList = new DuplicatesList();
            int duplicateId = 0;
            foreach(KeyValuePair<string, int> record in dictionary) {
                if (record.Value > 1) {
                    duplicateList.Duplicates.Add(
                        new Duplicate() {
                            Id = duplicateId,
                            Title = record.Key, 
                            Count = record.Value });
                    duplicateId++;
                }
            }
            e.View = Application.CreateDetailView(Application.CreateObjectSpace(), duplicateList);
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = false;
        }
    }
