    public async void taskRunner(){
        await Task.Run(() => { 
            try{
                await Step1(); 
            }catch(Exception e){
            }
            await Step2(); 
        }); 
    } 
