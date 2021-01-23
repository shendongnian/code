    using UnityEngine;
    using System.Collections;
    public class Display : MonoBehaviour
    {
        public GameObject[] Bubbles;
        void Start()
        {
            InitBubbles();
            StartCoroutine(PopBubbles()); //Instead of "PopBubbles", use PopBubbles() to avoid runtime overhead
        }
        public IEnumerator PopBubbles()
        {
            foreach (GameObject b in Bubbles)
            {
                b.transform.localScale = new Vector3(0f, 0f, 0f);
                while (Vector3.SqrMagnitude(Vector3.one - b.transform.localScale) > 0.05f)
                {
                    b.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
                    yield return null;
                }
                yield return new WaitForSeconds(0.5f);
                b.transform.localScale = new Vector3(0f, 0f, 0f);
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
        public void InitBubbles()
        {
            foreach (var bubble in Bubbles)
            {
                bubble.transform.localScale = Vector3.zero;
            }
        }
    }
