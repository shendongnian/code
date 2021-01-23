    class DownloadFilesTask extends AsyncTask<Void, Integer, Long> {
        protected Long doInBackground(Void... params) {
            long totalSize = 0;
    
            try {
                String url = "http://kepler.sos.ca.gov/";
                Connection.Response response = Jsoup.connect(url)
                        .method(Connection.Method.GET)
                        .execute();
    
                Document responseDocument = response.parse();
                Map<String, String> loginCookies = response.cookies();
    
    
                Element eventValidation = responseDocument.select("input[name=__EVENTVALIDATION]").first();
                String validationKey = eventValidation.attr("value");
    
                Element viewState = responseDocument.select("input[name=__VIEWSTATE]").first();
                String viewStateKey = viewState.attr("value");
    
                response = Jsoup.connect(url)
                        .cookies(loginCookies)
                        .data("__EVENTTARGET", "")
                        .data("__EVENTARGUMENT", "")
                        .data("__LASTFOCUS", "")
                        .data("__VIEWSTATE", viewStateKey)
                        .data("__VIEWSTATEENCRYPTED", "")
                        .data("__EVENTVALIDATION", validationKey)
                        .data("ctl00$content_placeholder_body$BusinessSearch1$TextBox_NameSearch", "aaa")  // <- search
                        .data("ctl00$content_placeholder_body$BusinessSearch1$RadioButtonList_SearchType", "Corporation Name")
                        .data("ctl00$content_placeholder_body$BusinessSearch1$Button_Search", "Search")
    
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
