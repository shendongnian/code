    private bool isInside = false;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player") == false){ return; }
        isInside = true;
        Fire();
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("Player") == false){ return; }
        isInside = false;
        timer  = 0f;
    }
    private float timer = 0f;
    private float waitTime = 0.2f;
    void Update(){
        if(isInside == false) { return; }
        if(timer > waitTime){
            timer = 0f;
            Fire();
        }
        timer += Time.deltaTime;
    }
