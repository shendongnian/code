    using UnityEngine;
    using System.Collections;
    using UnityStandardAssets.CrossPlatformInput;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace UnityStandardAssets.CrossPlatformInput
    {
        public class TouchPadEventCoordinator : MonoBehaviour
        {
            public int maxFrameCache = 7;
            string _horizontalAxisName;
            string _verticalAxisName;
            List<SwipeDirection> _directionCache = new List<SwipeDirection>();
            Dictionary<SwipeDirection, Action> _directionEventMap = new Dictionary<SwipeDirection, Action>();
            public Action SwipeUp { get; set; }
            public Action SwipeRight { get; set; }
            public Action SwipeDown { get; set; }
            public Action SwipeLeft { get; set; }
            public Action SwipeMultiUp { get; set; }
            public Action SwipeMultiRight { get; set; }
            public Action SwipeMultiDown { get; set; }
            public Action SwipeMultiLeft { get; set; }
            public TouchPadEventCoordinator(string horizontalAxisName, string verticalAxisName, Action swipeUp = null, Action swipeRight = null,
                Action swipeDown = null, Action swipeLeft = null, Action swipeMultiUp = null,
                Action swipeMultiRight = null, Action swipeMultiDown = null, Action swipeMultiLeft = null)
            {
                _horizontalAxisName = horizontalAxisName;
                _verticalAxisName = verticalAxisName;
                SwipeUp = swipeUp;
                SwipeDown = swipeDown;
                SwipeLeft = swipeLeft;
                SwipeRight = swipeRight;
                SwipeMultiUp = swipeMultiUp;
                SwipeMultiDown = swipeMultiDown;
                SwipeMultiLeft = swipeMultiLeft;
                SwipeMultiRight = swipeMultiRight;
                _directionEventMap.Add(SwipeDirection.Up, SwipeUp);
                _directionEventMap.Add(SwipeDirection.Down, SwipeDown);
                _directionEventMap.Add(SwipeDirection.Left, SwipeLeft);
                _directionEventMap.Add(SwipeDirection.Right, SwipeRight);
                _directionEventMap.Add(SwipeDirection.MultiUp, SwipeMultiUp);
                _directionEventMap.Add(SwipeDirection.MultiDown, SwipeMultiDown);
                _directionEventMap.Add(SwipeDirection.MultiLeft, SwipeMultiLeft);
                _directionEventMap.Add(SwipeDirection.MultiRight, SwipeMultiRight);
            }
            public void ProcessSwipeEvent(SwipeDirection swipeDirection)
            {
                if (false == Enum.IsDefined(typeof(SwipeDirection), swipeDirection))
                {
                    throw new Exception("Event Not defined");
                }
                _directionCache.Add(swipeDirection);
                if (_directionCache.Count == maxFrameCache)
                {
                    var averageSwipeDirection = GetAverageSwipeDirection();
                    Action swipeEvent = _directionEventMap[averageSwipeDirection];
                    if (null != swipeEvent)
                    {
                        swipeEvent();
                    }
                    ClearDirectionCache();
                }
            }
            public SwipeDirection GetAverageSwipeDirection()
            {
                return _directionCache.GroupBy(x => x)
                         .Select(directionGroup => new
                         {
                             directionGroup.Key,
                             Count = directionGroup.Count()
                         }).OrderByDescending(x => x.Count)
                         .FirstOrDefault().Key;
            }
            public void ClearDirectionCache()
            {
                _directionCache.Clear();
            }
            public enum SwipeDirection
            {
                Up,
                Right,
                Down,
                Left,
                MultiUp,
                MultiRight,
                MultiDown,
                MultiLeft,
            }
            public void UpdateSwipe()
            {
                var horizontal = CrossPlatformInputManager.GetAxis(_horizontalAxisName);
                var vertical = CrossPlatformInputManager.GetAxis(_verticalAxisName);
                //No Touch Occured
                if (vertical == 0 && horizontal == 0)
                {
                    return;
                }
                if (Input.touchCount > 1)
                {
                }
                //If they swipe at exactly a 45 register as horizontal so atleast we registered a hit
                if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
                {
                    HandleHorizontalMovement(horizontal);
                }
                else
                {
                    HandleVerticalMovement(vertical);
                }
            }
            protected void HandleVerticalMovement(float vertical)
            {
                if (vertical > 0)
                {
                    ProcessSwipeEvent(SwipeDirection.Up);
                }
                else
                {
                    ProcessSwipeEvent(SwipeDirection.Down);
                }
            }
            protected void HandleHorizontalMovement(float horizontal)
            {
                if (horizontal > 0)
                {
                    ProcessSwipeEvent(SwipeDirection.Right);
                }
                else
                {
                    ProcessSwipeEvent(SwipeDirection.Left);
                }
            }
            protected void HandleDepthMovement(float horizontal, float vertical)
            {
                //establish the most prodiment direction
                if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
                {
                    if (horizontal > 0)
                    {
                        ProcessSwipeEvent(SwipeDirection.MultiRight);
                    }
                    else if (horizontal < 0)
                    {
                        ProcessSwipeEvent(SwipeDirection.MultiLeft);
                    }
                }
                else
                {
                    if (vertical > 0)
                    {
                        ProcessSwipeEvent(SwipeDirection.MultiUp);
                    }
                    else if (vertical < 0)
                    {
                        ProcessSwipeEvent(SwipeDirection.MultiDown);
                    }
                }
            }
        }
    }
