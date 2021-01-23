    private void NextPage(){
      var page = currentPage + 1;
      if (page <= totalPages){
          SetDataSource(page);   
      } else {
          //do something else
      }
    }
 
