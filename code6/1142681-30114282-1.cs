    public void OnTriggerEnter(Collider other){
        if(other.tag == "angelic_sword_02"){
            totalhealth -= 50;
        }
    }
