    private async void go_Click(object sender, EventArgs e){
        for (int i = (int)startingPageNUD.Value; i <= (int)finishingPageNUD.Value; ++i) {
            RecipePage page = new RecipePage(page + i);
            await page.GetRecipeListAsync();
            //Some other code here
        }
    }
