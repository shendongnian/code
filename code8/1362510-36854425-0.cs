    public sealed class MyPopup : PopupWindow
    {
        private readonly Action<int> _callbackMethod;
        private MyPopup(Activity context, Action<int> callbackMethod)
            : base(context.LayoutInflater.Inflate(Resource.Layout.Popup, null),
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent)
        {
            _callbackMethod = callbackMethod;
        }
        public static Task<int> GetNumber(Activity mainActivity, Button button)
        {
            var t = new TaskCompletionSource<int>();
            var popupWindow = new MyPopup(mainActivity, i => t.TrySetResult(i));
            popupWindow.Show(button);
            return t.Task;
        }
        private void Show(View anchor)
        {
            SetActionForChildButtons(anchor, View_Click);
            ShowAsDropDown(anchor);
        }
        private void SetActionForChildButtons(View parent, EventHandler e)
        {
            var button = parent as Button;
            if (button != null)
            {
                button.Click += e;
                return;
            }
            var viewGroup = parent as ViewGroup;
            if (viewGroup == null)
                return;
            for (var i = 0; i < viewGroup.ChildCount; i++)
            {
                var view = viewGroup.GetChildAt(i);
                SetActionForChildButtons(view, e);
            }
        }
        private void View_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;
            int number;
            if (int.TryParse(button.Text, out number))
                _callbackMethod?.Invoke(number);
            Dismiss();
        }
    }
