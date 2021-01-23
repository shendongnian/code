    public class PlayerInput : MonoBehaviour
    {
    
        private GridManager gridManager;
        public LayerMask Tiles;
        private GameObject activeTile;
    
        void Awake()
        {
            gridManager = GetComponent();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (activeTile == null)
                    SelectTile();
                else
                    AttemptMove();
            }
        }
    
        void SelectTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 50f, Tiles);
            if (hit)
                activeTile = hit.collider.gameObject;
        }
    
        void AttemptMove()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 50f, Tiles);
            if (hit)
            {
                if (NeighborCheck(hit.collider.gameObject))
                {
                    activeTile.GetComponent<CharacterController>().Move(hit.collider.gameObject.transform.position);
                    hit.collider.gameObject.GetComponent<CharacterController>().Move(activeTile.transform.position);
                    gridManager.CheckMatches();
                }
            }
        }
    
        bool NeighborCheck(GameObject objectToCheck)
        {
            int xDifference = Mathf.Abs((int)(activeTile.transform.position.x - objectToCheck.transform.position.x));
            int yDifference = Mathf.Abs((int)(activeTile.transform.position.y - objectToCheck.transform.position.y));
    
            if (xDifference + yDifference == 1)
                return true;
            else
                return false;
        }
    
    
        void Awake()
        {
            gameObject.GetComponent<GridManager>();
        }
    
        public void Move(Vector2 destination)
        {
            transform.position = destination; // provisional
        }
    }
