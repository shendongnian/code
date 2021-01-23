    using UnityEngine;
    using System.Collections;
    public class Example : MonoBehaviour {
    int Example;
    // Use this for initialization
    void Start () {
    Example = 1;
    }
    // Update is called once per frame
    void Update () {
    Example = Example * 2;
    Debug.Log(Example);
    }
}
