    var editText = FindViewById<EditText>(Resource.Id.MyEditText);
    editText.SetText("hello", TextView.BufferType.Spannable);
    var myTextView = FindViewById<TextView>(Resource.Id.MyTextView);
    
    try
    {
        ISpannable t21 = editText.TextFormatted.JavaCast<ISpannable>();
        ISpanned t22 = editText.TextFormatted.JavaCast<ISpanned>();
    }
    catch (Exception exception)
    {
        myTextView.Text = exception.Message;
    }
