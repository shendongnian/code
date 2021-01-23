    class TestAsyncTask extends AsyncTask<Void, Integer, Long> {
        protected Long doInBackground(Void... params) {
            long totalSize = 0;
    
            try {
                String url = "http://kepler.sos.ca.gov/";
                Connection.Response response = Jsoup.connect(url)
                        .method(Connection.Method.GET)
                        .execute();
    
                Document responseDocument = response.parse();
    
                Element eventValidation = responseDocument.select("input[name=__EVENTVALIDATION]").first();
                Element viewState = responseDocument.select("input[name=__VIEWSTATE]").first();
                response = Jsoup.connect(url)
                        .data("__VIEWSTATE", viewState.attr("value"))
                        .data("__EVENTVALIDATION", eventValidation.attr("value"))
                        .data("ctl00_content_placeholder_body_BusinessSearch1_TextBox_NameSearch", "escrow")  // <- search
                        .data("ctl00_content_placeholder_body_BusinessSearch1_RadioButtonList_SearchType", "Corporation Name")
                        .data("ctl00_content_placeholder_body_BusinessSearch1_Button_Search", "Search")
    
                        .method(Connection.Method.POST)
                        .followRedirects(true)
                        .execute();
                Document document = response.parse(); //search results
                System.out.println(document);
    
            } catch (IOException e) {
                e.printStackTrace();
            }
    
            return totalSize;
        }
    
        protected void onProgressUpdate(Integer... progress) {
        }
    
        protected void onPostExecute(Long result) {
        }
    }
