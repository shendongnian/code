    using UnityEngine;
    using System.Collections;
    
    public class Questions {
    public Questions dpoint; // u can set this on unity editor by just draging and dropping the parent object here.
    void Start () {
        //or you can get it from code I belive
        dpoint = transform.parent.GetComponent<Question>();
        QuestionObject.questionText = "asd";
    }
    
    // Update is called once per frame
    void Update () {    
        base.QuestionObject.questionText = "asd2";
    }
    
    }
