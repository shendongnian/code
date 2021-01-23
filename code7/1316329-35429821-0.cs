    public class GameCoordinator : MonoBehaviour
    {
        public List<Participant> participants;
        private int currentParticipantIdx = -1;
        private Participant CurrentParticipant
        {
            get { return participants[currentParticipantIdx]; }
        }
        private void Start()
        {
            PlayNextMove();
        }
        private void PlayNextMove()
        {
            ProceedToNextParticipant();
            CurrentParticipant.OnMoveCompleted += OnMoveCompleted;
            CurrentParticipant.BeginMove();
        }
        private void OnMoveCompleted()
        {
            CurrentParticipant.OnMoveCompleted -= OnMoveCompleted;
            StartCoroutine(PlayNextMoveIn(2.0f));
        }
        private IEnumerator PlayNextMoveIn(float countdown)
        {
            yield return new WaitForSeconds(countdown);
            PlayNextMove();
        }
        private void ProceedToNextParticipant()
        {
            ++currentParticipantIdx;
            if (currentParticipantIdx == participants.Count)
                currentParticipantIdx = 0;
        }
    }
    public class Participant : MonoBehaviour
    {
        public event Action OnMoveCompleted;
        public void BeginMove()
        {
            //
        }
    }
