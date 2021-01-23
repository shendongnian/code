    using UnityEngine;
    
    [RequireComponent(typeof(Rigidbody))]
    public class MoveExample : MonoBehaviour {
        public float Acceleration = 4f;
        public float Speed = 4f;
    
        private Vector2 _velocity = Vector2.zero;
        private Rigidbody _rigidbody;
    
        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }
    
        // movement methods
        public void Move(float velocity) { _velocity.x = velocity * Speed; }
        public void MoveForward() { Move(1f); }
        public void MoveBackwards() { Move(-1f); }
        public void StopMoving() { Move(0f); }
    
        private void Update() {
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, _velocity, Time.deltaTime * Acceleration);
        }
    }
