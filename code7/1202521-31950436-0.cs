    void OnGUI(){
    if(GUI.Button(new Rect(8*Screen.width/10 ,Screen.height/10, Screen.width/10,Screen.height/10),"Play")){
        if(!Pa.isPlaying)
           Pa.Play();
        else
           Pa.Stop();
        if(!Pa2.isPlaying)
           Pa2.Play();
        else
           Pa2.Stop();
      }
    }
