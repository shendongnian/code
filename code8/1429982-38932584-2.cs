    public class DoAsyncTask extends AsyncTask<Long, Integer, String> 
    {
         YouActivityName  _activity;
         public DoAsyncTask(YouActivityName activity)
         {
            _activity = activity;
         }
    
         @Override
         protected String doInBackground(Long... params) {
            String longString = ThirdAPIClass.GiveMeSomeCode(); //Or work here
            return lognString;
         }
         @Override
         protected void onPostExecute(String result) {
            
            if(_activity != null) {
              _activity.someMethodInMainActivity(result);
            }
         }
    }
