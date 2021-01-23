    Dictionary<float, Action> musicSequence = new Dictionary<float, Action>();
    void addBulletToList (string direction, float time){
        musicSequence.Add(time, () => musicControl.spawnBullet(direction, time));
    }
    
    void spawnBullet(string direction, float time){
        go = (GameObject)Instantiate(Resources.Load(direction));
    }
    if (CurrentMusicTime == musicSequence[index]){
        musicSequence[index]();
        next index
    }
