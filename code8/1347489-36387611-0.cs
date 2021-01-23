    public class RayShooter : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetMouseButtonDown(1))     // 1 is rightclick, don't know if you might want leftclick instead
            {
                RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint((Input.mousePosition)), -Vector2.up);
                if(hit.collider != null)
                {
                    GameObject target = hit.collider.gameObject;
                    target.GetComponent<Enemy>().dealDamage(PlayerScript.damage);
                    // "Enemy" is the name of the script on the things you shoot
                }
            }
        }
    }
