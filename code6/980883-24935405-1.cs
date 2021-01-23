    private void backgroundWorker1_DoWork(object state)
    {
        String text = (String)state;
        // Please use List<Artikel> as return value.
        allArtikels = DatabaseConn.GetAllArtikelsArrayList(false, text);
 
        lock(syncObjetc){
            if (--counter < THREASHOLD){
                textbox1.BeginInvoke(compareAndUseResult, new object[]{text, allArtikels});
            }
        }
    }
