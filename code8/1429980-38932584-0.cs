    public class DoAsyncTask extends AsyncTask<Long, Integer, Integer> 
    {
         YouActivityName  _activity;
         public DoAsyncTask(YouActivityName activity)
         {
            _activity = activity;
         }
    
         @Override
         protected void onPostExecute(String result) {
            _activity.someMethodInMainActivity(result);
         }
    }
