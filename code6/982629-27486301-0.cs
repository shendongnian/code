    using UnityEngine;
    using System.Collections;
    public class ExampleClass : MonoBehaviour {
        IEnumerator Example() {
            print(Time.time);
            yield return new WaitForSeconds(5);
            print(Time.time);
        }
    }
