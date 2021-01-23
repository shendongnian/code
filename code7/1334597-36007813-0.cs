    public interface OnCheckBoxClickListener{
        public void OnCheckboxClicked();
    }
    
    public class MyOnCheckBoxClickListener :OnCheckBoxClickListener {
        public void OnCheckboxClicked(){
        // Code for dismiss keyboard
        }
    }
    
    YourListAdapter adapter = new YourListAdapter(listener);
