    var expectedValue = from parent in context.ParentTransaction
				join child in context.ChildTransaction on parent.TransactionId equals child.TransactionId into gj
				from subset in gj.DefaultIfEmpty()
				let joined = new { Transaction = parent, Deposit = subset != null ? subset.Deposit : 0 }
				group joined by joined.Transaction
				into grouped
				let g = new { Transaction = grouped.Key, Deposit = grouped.Sum(e => e.Deposit) }
				where g.Transaction.PayAmount > g.Deposit
				select g.Transaction;
