    else if(PageNumber < vcnt)
    {
        //linkNext.Visible = true;
        // Change it to
        linkNext.Visible = !pagedData.IsLastPage;
        linkPrevious.Visible = !pagedData.IsFirstPage;
    }
