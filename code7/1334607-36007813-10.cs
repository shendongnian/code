    class MyActivity {
          public interface OnCheckBoxClickListener{
              public void OnCheckboxClicked();
          }
            
          public class MyOnCheckBoxClickListener :OnCheckBoxClickListener {
    
              private WeakReference<Context> mContext;
    
              public MyOnCheckBoxClickListener(Context context){
                     mContext = new WeakReference<Context>(context);
              }
    
              public void OnCheckboxClicked(){
              Context context = null;
              mContext.TryGetTarget(out context);
    
              var editText = (context as Activity).FindViewById<EditText>(Resource.Id.edittextId);
              editText.ClearFocus();
              }
          }
            
          YourListAdapter adapter = new YourListAdapter(new MyOnCheckBoxClickListener(this)); 
    }
    
