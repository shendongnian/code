    public class PickerListCell : TextCell
    {
        public PickerListCell (PickerPage myPage)
        {
            var moreAction = new MenuItem { Text = App.Translate ("Edit") };
            moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
            moreAction.Clicked += async (sender, e) => {
                var mi = ((MenuItem)sender);
                var option = (PickerListPage.OptionListItem)mi.CommandParameter;
                var recId = new Guid (option.Value);
                myPage.OnEditAction();
            };
          ContextActions.Add (moreAction);
        }
    }
