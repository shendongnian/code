    public class AnswerForm<T>
    {
        private readonly IList<T> _list;
   
        public AnswerForm()
  	    {
		    _list = new List<T>();
  	    }
        public void Add(T button)
        {
            _list.Add(button);
        }
    }
    public class RadioButtonClass:AnswerForm<RadioButton>
    {
    }
    public class CheckBoxClass : AnswerForm<CheckBox>
    {
    }
